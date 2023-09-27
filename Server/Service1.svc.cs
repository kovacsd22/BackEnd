﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Server.Models;

namespace Server
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
       public static Dictionary<string,Felhasznalo> BejelentkezettFelhasznalok=new Dictionary<string, Felhasznalo>();

        public List<Felhasznalo> FelhasznaloLista_CS()
        {
            List<Felhasznalo> lista=new List<Felhasznalo> ();
            Controllers.FelhasznalokController felhasznalokController= new Controllers.FelhasznalokController();
            List<Record> records = felhasznalokController.Select();
            foreach (Record record in records)
            {
                lista.Add(record as Felhasznalo);
            }
            return lista;
        }

        public List<Felhasznalo> FelhasznaloLista_Web()
        {
            return FelhasznaloLista_CS();
        }

        public string FelhasznaloHozzaAd_CS(Felhasznalo felhasznalo)
        {
            Controllers.FelhasznalokController felhasznalokController=new Controllers.FelhasznalokController ();
            return felhasznalokController.Insert(felhasznalo);
        }

        public string FelhasznaloHozzaAd_Web(Felhasznalo felhasznalo)
        {
            return FelhasznaloHozzaAd_CS(felhasznalo);
        }

        public string FelhasznaloModosit_CS(Felhasznalo felhasznalo)
        {
            Controllers.FelhasznalokController felhasznalokController = new Controllers.FelhasznalokController();
            return felhasznalokController.Update(felhasznalo);
        }

        public string FelhasznaloModosit_Web(Felhasznalo felhasznalo)
        {
            return FelhasznaloModosit_CS(felhasznalo);
        }

        public string FelhasznaloTorol_CS(int id)
        {
            Controllers.FelhasznalokController felhasznalokController = new Controllers.FelhasznalokController();
            return felhasznalokController.Delete(id);
        }

        public string FelhasznaloTorol_Web(int id)
        {
            return FelhasznaloTorol_CS(id);
        }
    }
}
