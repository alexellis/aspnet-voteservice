using System;
using System.Collections;
using System.Configuration;
using System.Web.Http;

namespace VoteService.Controllers
{
    [RoutePrefix("v1/voting")]
    public class VoteController : ApiController
    {
        public string ConnectionString
        {
            get
            {
                return new Db().ConnectionString;
            }
        }

        public class DebugStuff
        {
            public IDictionary Machine
            {
                get; set;
            }
            public string ConnectionString
            {
                get; set;
            }
            public IDictionary Process { get; internal set; }
            public IDictionary User { get; internal set; }
        }

        [HttpGet]
        [Route("debug")]
        public DebugStuff GetDebug()
        {
            var variables = Environment.GetEnvironmentVariables(EnvironmentVariableTarget.Machine);

            return new DebugStuff { ConnectionString = ConnectionString };
        }

        [HttpGet]
        [Route("")]
        public VoteResult Get()
        {
            var results = new VoteResult
            {

            };

            using (var connection = System.Data.SqlClient.SqlClientFactory.Instance.CreateConnection())
            {
                connection.ConnectionString = ConnectionString;
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "select vote, count(vote) as votes from votes.dbo.votes group by vote";
                    command.CommandType = System.Data.CommandType.Text;
                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if ((string)reader["vote"] == "a")
                            {
                                results.VoteA = reader.GetInt32(reader.GetOrdinal("votes"));
                            }
                            else if ((string)reader["vote"] == "b")
                            {
                                results.VoteB = reader.GetInt32(reader.GetOrdinal("votes"));
                            }
                        }
                    }
                }
            }

            return results;
        }

        [HttpPost]
        [Route("submit/{voteid}/{vote}")]
        public SubmissionResult Submit(string voteid, string vote)
        {
            int result = 0;
            using (var connection = System.Data.SqlClient.SqlClientFactory.Instance.CreateConnection())
            {
                connection.ConnectionString = ConnectionString;
                connection.Open();
                var command = connection.CreateCommand();
                try
                {
                    command.CommandText = "insert into Votes.dbo.votes (id, vote) values('" + voteid + "','" + vote + "' );";
                    result = (int)command.ExecuteNonQuery();
                }
                catch
                {
                    command.CommandText = "update Votes.dbo.votes set vote = '" + vote + "' where id='" + voteid + "'";
                    result = (int)command.ExecuteNonQuery();
                }
            }

            return new SubmissionResult
            {
                Success = result == 1
            };
        }

        public class SubmissionResult
        {
            public int Total { get; set; }
            public bool Success
            {
                get; set;
            }
        }

        public class VoteResult
        {
            public int VoteA { get; set; }

            public int VoteB { get; set; }
        }
    }
}
