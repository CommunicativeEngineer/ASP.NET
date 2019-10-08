using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WeCare_PU.Entities;

namespace WeCare_PU.Metiers
{
    interface ITraitementUtilisateur
    {
        //Citoyen
        Citoyen GetCitoyen(int id);
        IEnumerable<Citoyen> GetAllCitoyens();
        IEnumerable<Citoyen> FindCitoyen(Expression<Func<Citoyen, bool>> predicate);
        void AddCitoyen(Citoyen entity);
        void AddRangeCitoyen(IEnumerable<Citoyen> entity);
        void RemoveCitoyen(Citoyen entity);
        void RemoveRangeCitoyen(IEnumerable<Citoyen> entities);
        void UpdateCitoyen(Citoyen entity);
        bool ExistsCitoyen(int id);

        //Association
        Association GetAssociation(int id);
        IEnumerable<Association> GetAllAssociations();
        IEnumerable<Association> FindAssociation(Expression<Func<Association, bool>> predicate);
        void AddAssociation(Association entity);
        void AddRangeAssociation(IEnumerable<Association> entity);
        void RemoveAssociation(Association entity);
        void RemoveRangeAssociation(IEnumerable<Association> entities);
        void UpdateAssociation(Association entity);
        bool ExistsAssociation(int id);

        //Administrateur
        Administrateur GetAdministrateur(int id);
        IEnumerable<Administrateur> GetAllAdministrateurs();
        IEnumerable<Administrateur> FindAdministrateur(Expression<Func<Administrateur, bool>> predicate);
        void AddAdministrateur(Administrateur entity);
        void AddRangeAdministrateur(IEnumerable<Administrateur> entity);
        void RemoveAdministrateur(Administrateur entity);
        void RemoveRangeAdministrateur(IEnumerable<Administrateur> entities);
        void UpdateAdministrateur(Administrateur entity);
        bool ExistsAdministrateur(int id);

        //Authentification
    }
}
