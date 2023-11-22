﻿using QCYDS9_HFT_2023241.Models;
using QCYDS9_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCYDS9_HFT_2023241.Logic
{
    public class MissionLogic : IMissionLogic
    {
      
        IRepository<Mission> repo;


        public MissionLogic(IRepository<Mission> repo)
        {
            this.repo = repo;
        }

        public void Create(Mission item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Mission Read(int id)
        {
            var mission = this.repo.Read(id);
            if (mission == null)
            {
                throw new ArgumentException("Mission not exists.");
            }
            return this.repo.Read(id);
        }

        public IEnumerable<Mission> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Mission item)
        {
            this.repo.Update(item);
        }
        //átlagosan  asztonauta éetkora
        public double AverageAstonautsAgeInMission(int missionId)
        {
            var team = this.repo
            .ReadAll()
            .FirstOrDefault(t => t.MissionId == missionId);
            return team.Astronauts
            .Select(p => p.Age)
            .Average();
        }


    }
}