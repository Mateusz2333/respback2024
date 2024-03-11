using ApplicationCore.Interfaces.Repository;
using BackendLab01;
using System;
using System.Collections.Generic;

namespace Infrastructure.Memory
{
    public static class SeedData
    {
        public static void Seed(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var provider = scope.ServiceProvider;
                var quizRepo = provider.GetService<IGenericRepository<Quiz, int>>();

                
                if (quizRepo != null)
                {
                    
                    AddSampleQuizzes(quizRepo);
                }
                else
                {
                    Console.WriteLine("Nie udało się uzyskać repozytorium quizów.");
                }
            }
        }

        private static void AddSampleQuizzes(IGenericRepository<Quiz, int> quizRepo)
        {
            var quiz1 = new Quiz(1, new List<QuizItem>
            {
                new QuizItem(1, "Jakie jest wynikiem działania 2 + 4?", new List<string>{"6", "7", "8"}, "6"),
                new QuizItem(2, "Jakie jest wynikiem działania 5 - 3?", new List<string>{"2", "3", "4"}, "2"),
                new QuizItem(3, "Jakie jest wynikiem działania 8 + 9?", new List<string>{"15", "16", "17"}, "17"),
            }, "Matematyka - dodawanie i odejmowanie");

            var quiz2 = new Quiz(2, new List<QuizItem>
            {
                new QuizItem(1, "Jakie jest wynikiem działania 20 - 7?", new List<string>{"13", "14", "15"}, "13"),
                new QuizItem(2, "Jakie jest wynikiem działania 18 + 7?", new List<string>{"24", "25", "26"}, "25"),
                new QuizItem(3, "Jakie jest wynikiem działania 50 - 32?", new List<string>{"16", "17", "18"}, "18"),
            }, "Matematyka - dodawanie i odejmowanie");

            quizRepo.Add(quiz1);
            quizRepo.Add(quiz2);
        }
    }
}
