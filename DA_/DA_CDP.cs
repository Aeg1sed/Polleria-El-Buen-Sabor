﻿using BE_;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util_;

namespace DA_
{
    public class DA_CDP
    {
        public string SiguienteIdOrdenPedido()
        {
            string valor = "";
            SqlDataReader rd = null;
            using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[SP_NextCDP]", cn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    valor = rd["CDPActual"].ToString();
                }
                rd.Close();
            }

            return valor;
        }
        public List<BE_CDP> ListaCDP()
        {
            SqlDataReader rd = null;
            using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
            {

                cn.Open();
                SqlCommand cmd = new SqlCommand("SELECT TipoId, descCDP from TipoCDP;", cn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.Text;
                rd = cmd.ExecuteReader();
                BE_CDP cdp;
                List<BE_CDP> ListaCDP = new List<BE_CDP>();
                while (rd.Read())
                {
                    cdp = new BE_CDP();
                    cdp.Valor = int.Parse(rd["TipoId"].ToString());
                    cdp.Descripcion = rd["descCDP"].ToString();
                    ListaCDP.Add(cdp);
                }
                return ListaCDP;
            }
        }
    }
}
