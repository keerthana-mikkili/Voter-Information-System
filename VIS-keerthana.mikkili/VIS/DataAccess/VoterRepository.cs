﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataAccess
{
    public class VoterRepository
    {
        private VISContext db;
        public VoterRepository()
        {
            db = new VISContext();
        }
        public AdminUser ValidateUser(string emailId,string password)
        {
            AdminUser adminUser = null;
            try
            {
                adminUser = db.AdminUsers.Where(v => v.EmailId == emailId && v.Password == password).FirstOrDefault();
            }
            catch
            {
                adminUser = null;
            }
            return adminUser;
        }
        public bool AddVoter(Voter voterInfo)
        {
            if(voterInfo==null)
            {
                return false;
            }
            try
            {
                db.Voters.Add(voterInfo);
                db.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }
        public Voter FindByPK(int voterId)
        {
            Voter voter = null;
            try
            {
                voter = db.Voters.Find(voterId);
            }
            catch
            {
                voter = null;
            }
            return voter;
        }
        public bool UpdateVoter(Voter voterInfo)
        {
            if (voterInfo == null)
            {
                return false;
            }
            try
            {
                db.Entry(voterInfo).State=EntityState.Modified;
                db.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool DeleteVoter(int id)
        {
            try
            {
                Voter voter = FindByPK(id);
                db.Voters.Remove(voter);
                db.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }
        public List<Voter> GetVotersList()
        {
            try
            {
                return db.Voters.ToList();
            }
            catch(Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}
