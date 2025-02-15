﻿using BlackBoards.Domain;
using BlackBoards.Domain.BlackBoards;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBoards
{
    public class Picture : Item
    {
        private string imgPath;
        private string description;
        public Picture()
        {
            this.Dimension = new Dimension(50, 50);
            this.comments = new List<Comment>();
            this.Origin = new Coordinate();
            this.description = "default description";
            this.imgPath = "";
        }
        public override bool IsPicture()
        {
            return true;
        }
        public Image Img()
        {
            return Image.FromFile(this.imgPath);
        }
        public string ImgPath
        {
            get
            {
                return this.imgPath;
            }
            set
            {
                this.imgPath = value;
            }
        }
        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
            }
        }
        public Picture(Dimension aDimension, List<Comment> someComments, Coordinate anOrigin)
        {
            this.Dimension = aDimension;
            this.comments = someComments;
            this.Origin = anOrigin;
        }
        private string getDefaultPicturePath()
        {
            string proyectPath = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            string defualtImagePath = proyectPath + "\\Images\\default.jpg";
            return defualtImagePath;
        }
        

        private bool IsDescriptionValid()
        {
            bool valid = true;
            if (this.Description.Length == 0)
            {
                valid = false;
            }
            return valid;
        }
        private bool IsImageValid()
        {
            bool valid = true;
            if (this.ImgPath.Equals(""))
            {
                valid = false;
            }
            return valid;
        }
        public ValidationReturn IsValid()
        {
            ValidationReturn validation = new ValidationReturn(false, "Error");
            bool validDescription = this.IsDescriptionValid();
            bool validImage = this.IsImageValid();
            if (!validDescription)
            {
                validation.Message = "El texto ingresado es vacio.";
                return validation;
            }
            if (!validImage)
            {
                validation.Message = "No se ha cargado ninguna foto.";
                return validation;
            }
            validation.Message = "OK";
            validation.Validation = true;
            return validation;
        }
        public override string ToString()
        {
            return this.description;
        }
    }
}

