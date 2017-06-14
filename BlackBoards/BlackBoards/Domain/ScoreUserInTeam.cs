﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBoards.Domain
{
    public class ScoreUserInTeam
    {
        private Team team;
        private User user;
        private Score score;
        public ScoreUserInTeam()
        {
            this.team = new Team();
            this.user = new Admin();
            this.score = new Score();
        }
        public Team Team
        {
            get
            {
                return this.team;
            }
            set
            {
                this.team = value;
            }
        }
        public User User
        {
            get
            {
                return this.user;
            }
            set
            {
                this.user = value;
            }
        }
        public Score Score
        {
            get
            {
                return this.score;
            }
            set
            {
                this.score = value;
            }
        }
        private bool IsOfUser(User user)
        {
            return this.user.Equals(user);
        }
        private bool IsOfTeam(Team team)
        {
            return this.team.Equals(team);
        }
        private bool IsThisScore(Score score)
        {
            return this.score.Equals(score);
        }
        public override bool Equals(object aScoreUserInTeam)
        {
            if (aScoreUserInTeam == null)
            {
                return false;
            }
            ScoreUserInTeam otherScoreUserInTeam = aScoreUserInTeam as ScoreUserInTeam;
            if ((System.Object)otherScoreUserInTeam == null)
            {
                return false;
            }
            bool scoreEquals = this.IsThisScore(otherScoreUserInTeam.Score);
            bool teamEquals = this.IsOfTeam(otherScoreUserInTeam.Team);
            bool userEquals = this.IsOfUser(otherScoreUserInTeam.User);
            return (scoreEquals && teamEquals && userEquals);
        }
    }
}
