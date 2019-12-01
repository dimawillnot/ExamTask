using DBO.Entities;
using ExamTask.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ExamTask.Services.Converters
{
    public static class ArticleConverter
    {
        public static Article ConvertToDB(ArticleXmlModel xmlModel)
        {
            var dbArticle = new Article()
            {
                Amount = xmlModel.Amount,
                BrutPrice = (double)xmlModel.BrutPrice,
                Nomenclature = xmlModel.ArtNum,
                Title = xmlModel.Title
            };

            return dbArticle;
        }

        public static ArticleVM ConvertToVM(Article arcticleDb)
        {
            return new ArticleVM()
            {
                Amount = arcticleDb.Amount,
                BrutPrice = (decimal)arcticleDb.BrutPrice,
                ArtNum = arcticleDb.Nomenclature,
                Title = arcticleDb.Title
            };
        }
    }
}
