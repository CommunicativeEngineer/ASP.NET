using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WeCare_PU.DAL;
using WeCare_PU.Entities;

namespace WeCare_PU.Metiers
{
    public class ImplTraitementUtilisateur : ITraitementUtilisateur
    {
        private Repository<Citoyen> _contextCitoyen = new Repository<Citoyen>();
        private Repository<Administrateur> _contextAdmin = new Repository<Administrateur>();
        private Repository<Association> _contextAssociation = new Repository<Association>();

        public void AddAdministrateur(Administrateur entity)
        {
            _contextAdmin.Add(entity);
        }

        public void AddAssociation(Association entity)
        {
            _contextAssociation.Add(entity);
        }

        public void AddCitoyen(Citoyen entity)
        {
            _contextCitoyen.Add(entity);
        }

        public void AddRangeAdministrateur(IEnumerable<Administrateur> entity)
        {
            _contextAdmin.AddRange(entity);
        }

        public void AddRangeAssociation(IEnumerable<Association> entity)
        {
            _contextAssociation.AddRange(entity);
        }

        public void AddRangeCitoyen(IEnumerable<Citoyen> entity)
        {
            _contextCitoyen.AddRange(entity);
        }

        public bool ExistsAdministrateur(int id)
        {
           return _contextAdmin.Exists(id);
        }

        public bool ExistsAssociation(int id)
        {
            return _contextAssociation.Exists(id);
        }

        public bool ExistsCitoyen(int id)
        {
            return _contextCitoyen.Exists(id);
        }

        public IEnumerable<Administrateur> FindAdministrateur(Expression<Func<Administrateur, bool>> predicate)
        {
            return _contextAdmin.Find(predicate);
        }

        public IEnumerable<Association> FindAssociation(Expression<Func<Association, bool>> predicate)
        {
            return _contextAssociation.Find(predicate);
        }

        public IEnumerable<Citoyen> FindCitoyen(Expression<Func<Citoyen, bool>> predicate)
        {
            return _contextCitoyen.Find(predicate);
        }

        public Administrateur GetAdministrateur(int id)
        {
            return _contextAdmin.Get(id);
        }

        public IEnumerable<Administrateur> GetAllAdministrateurs()
        {
            return _contextAdmin.GetAll();
        }

        public IEnumerable<Association> GetAllAssociations()
        {
            return _contextAssociation.GetAll();
        }

        public IEnumerable<Citoyen> GetAllCitoyens()
        {
            return _contextCitoyen.GetAll();
        }

        public Association GetAssociation(int id)
        {
            return _contextAssociation.Get(id);
        }

        public Citoyen GetCitoyen(int id)
        {
            return _contextCitoyen.Get(id);
        }

        public void RemoveAdministrateur(Administrateur entity)
        {
            _contextAdmin.Remove(entity);
        }

        public void RemoveAssociation(Association entity)
        {
            _contextAssociation.Remove(entity);
        }

        public void RemoveCitoyen(Citoyen entity)
        {
            _contextCitoyen.Remove(entity);
        }

        public void RemoveRangeAdministrateur(IEnumerable<Administrateur> entities)
        {
            _contextAdmin.RemoveRange(entities);
        }

        public void RemoveRangeAssociation(IEnumerable<Association> entities)
        {
            _contextAssociation.RemoveRange(entities);
        }

        public void RemoveRangeCitoyen(IEnumerable<Citoyen> entities)
        {
            _contextCitoyen.RemoveRange(entities);
        }

        public void UpdateAdministrateur(Administrateur entity)
        {
            _contextAdmin.Update(entity);
        }

        public void UpdateAssociation(Association entity)
        {
            _contextAssociation.Update(entity);
        }

        public void UpdateCitoyen(Citoyen entity)
        {
            _contextCitoyen.Update(entity);
        }
    }
}
