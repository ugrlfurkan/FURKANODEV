﻿using DAL;
using OkulApp.MODEL;
using System;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace OkulApp.BLL//Bussiness Logic Layer
{
    public class OgrenciBL
    {
        private Helper hlp;
        public OgrenciBL() 
        {
            hlp = Helper.Instance;
        }
        public bool OgrenciEkle(Ogrenci ogr)
        {
            try
            {
                SqlParameter[] p = {
                                  new SqlParameter("@Ad",ogr.Ad),
                                  new SqlParameter("@Soyad",ogr.Soyad),
                                  new SqlParameter("@Numara",ogr.Numara)
                            };

                var hlp = new Helper();
                return hlp.ExecuteNonQuery("Insert into tblOgrenciler (Ad,Soyad,Numara) values (@Ad,@Soyad,@Numara)", p) > 0;
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                //if (cn != null && cn.State != ConnectionState.Closed)
                //{
                //    //cn.Close();
                //    cn.Dispose();

                //    cmd.Dispose();
                //}
            }
        }

        public Ogrenci OgrenciBul(string numara)
        {

            try
            {

           

            var hlp = new Helper();
            SqlParameter[] p = { new SqlParameter("@Numara", numara) };
            var dr = hlp.ExecuteReader("Select OgrenciId,Ad,Soyad,Numara from tblOgrenciler where Numara=@Numara", p);
            Ogrenci ogr = null;
            if (dr.Read())
            {
                ogr = new Ogrenci();
                ogr.Ad = dr["Ad"].ToString();
                ogr.Soyad = dr["Soyad"].ToString();
                ogr.Numara = dr["Numara"].ToString();
                ogr.Ogrenciid = Convert.ToInt32(dr["OgrenciId"]);
            }
            dr.Close();
            return ogr;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool OgrenciSil(int id)
        {
            try
            {

            
            SqlParameter[] p = { new SqlParameter("@Id", id) };
            Helper hlp = new Helper();
            return hlp.ExecuteNonQuery("Delete from tblOgrenciler where OgrenciId=@Id", p) > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool OgrenciGuncelle(Ogrenci ogr)
        {
            try
            {

            
            SqlParameter[] p = { new SqlParameter("@Ad",ogr.Ad),
            new SqlParameter("@Soyad",ogr.Soyad),
            new SqlParameter("@Numara",ogr.Numara),
            new SqlParameter("@OgrenciId",ogr.Ogrenciid)};

            Helper hlp = new Helper();
            return hlp.ExecuteNonQuery("Update tblOgrenciler set Ad=@Ad,Soyad=@Soyad,Numara=@Numara where OgrenciId=@OgrenciId", p) > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
