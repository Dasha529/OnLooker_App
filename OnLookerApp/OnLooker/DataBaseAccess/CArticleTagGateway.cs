﻿using System;
using System.Data.SqlClient;

namespace OnLooker
{
    public class CArticleTagGateway
    {
        public void AddRelation(int tagid, int articleid)
        {
            string sqlExpression = "sp_InsertArticleTag";
            using (SqlConnection conn = DBConnection.Instance.GetConnection())
            {
                conn.Open();
                SqlCommand command = new SqlCommand(sqlExpression, conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter articleIdParam = new SqlParameter
                {
                    ParameterName = "@articleId",
                    Value = articleid
                };
                command.Parameters.Add(articleIdParam);
                SqlParameter tagIdParam = new SqlParameter
                {
                    ParameterName = "@tagId",
                    Value = tagid
                };
                command.Parameters.Add(tagIdParam);

                var result = command.ExecuteScalar();

                Console.WriteLine("Id добавленного объекта: {0}", result);
            }
        }
    }
}
