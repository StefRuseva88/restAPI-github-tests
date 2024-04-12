using RestSharpServices;
using System.Net;
using System.Reflection.Emit;
using System.Text.Json;
using RestSharp;
using RestSharp.Authenticators;
using NUnit.Framework.Internal;
using RestSharpServices.Models;
using System;

namespace TestGitHubApi
{
    public class TestGitHubApi
    {
        private GitHubApiClient client;
        private static string repo;
        private static int lastCreatedIssueNumber;
        private static int lastCreatedCommentId;


        [SetUp]
        public void Setup()
        {            
            client = new GitHubApiClient("https://api.github.com/repos/testnakov/", "StefRuseva88", "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");
            repo = "test-nakov-repo";
        }


        [Test, Order (1)]
        public void Test_GetAllIssuesFromARepo()
        {
            //Act
            var issues = client.GetAllIssues(repo);

            //Assert
            Assert.That(issues, Has.Count.GreaterThan(0), "There should be more than one issue.");

            foreach (var issue in issues)
            {
                Assert.That(issue.Id, Is.GreaterThan(0), "Issue ID should be greater than 0.");
                Assert.That(issue.Number, Is.GreaterThan(0), "Issue Number should be greater than 0.");
                Assert.That(issue.Title, Is.Not.Empty, "Issue Title should not be empty.");
            }
        }

        [Test, Order (2)]
        public void Test_GetIssueByValidNumber()
        {
            //Arrange
            int issueNumber = 1;
            //Act
            var issue = client.GetIssueByNumber(repo, issueNumber);
            //Assert
            Assert.That(issue, Is.Not.Null, "The response should contain issue data.");
            Assert.That(issue.Id, Is.GreaterThan(0), "Issue ID should be greater than 0.");
            Assert.That(issue.Number, Is.EqualTo(issueNumber), "The issue number should be as requested");
            Assert.That(issue.Title, Is.Not.Empty, "Issue Title should not be empty.");
        }
        
        [Test, Order (3)]
        public void Test_GetAllLabelsForIssue()
        {
            //Arrange
            int issueNumber = 6;
            //Act
            var labels = client.GetAllLabelsForIssue(repo, issueNumber);
            //Assert
            Assert.That(labels.Count, Is.GreaterThan(0));

            foreach (var label in labels)
            {
                Assert.That(label.Id, Is.GreaterThan(0), "Label ID should be greater than 0.");
                Assert.That(label.Name, Is.Not.Empty, "Label name should not be empty.");

                Console.WriteLine("Label: " + label.Id + " - Name: " + label.Name);
            }
        }

        [Test, Order (4)]
        public void Test_GetAllCommentsForIssue()
        {
            //Arrange
            int issueNumber = 6;
            //Act
            var comments = client.GetAllCommentsForIssue(repo, issueNumber);
            //Assert
            Assert.That(comments.Count, Is.GreaterThan(0));

            foreach (var comment in comments)
            {
                Assert.That(comment.Id, Is.GreaterThan(0), "Comment ID should be greater than 0.");
                Assert.That(comment.Body, Is.Not.Empty, "Comment body should not be empty.");

                Console.WriteLine("Comment: " + comment.Id + " - Body: " + comment.Body);
            }
        }

        [Test, Order(5)]
        public void Test_CreateGitHubIssue()
        {
            //Arrange
            string expectedTitle = "Create Your Own Title";
            string body = "Give Me Some Description";
            //Act
            var issue = client.CreateIssue(repo, expectedTitle, body);
            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(issue.Id, Is.GreaterThan(0));
                Assert.That(issue.Number, Is.GreaterThan(0));
                Assert.That(issue.Title, Is.Not.Empty);
                Assert.That(issue.Title, Is.EqualTo(expectedTitle));

            });
        }

        [Test, Order (6)]
        public void Test_CreateCommentOnGitHubIssue()
        {
            //Arrange
            int issueNumber = 5128;
            string body = "Body of the new Comment";
            //Act
            var comment = client.CreateCommentOnGitHubIssue(repo, issueNumber, body);
            //Assert
            Assert.That(comment.Body, Is.EqualTo(body));

            Console.WriteLine(comment.Id);
            lastCreatedCommentId = comment.Id;  
        }

        [Test, Order (7)]
        public void Test_GetCommentById()
        {
            //Arrange
            int commentId = 2045168289;
            //Act
            Comment comment = client.GetCommentById(repo, commentId);
            //Assert
            Assert.IsNotNull(comment, "Expected to retrieve a comment but got null.");
            Assert.That(comment.Id, Is.EqualTo(commentId), "The retreivet comment ID should match the requested comment ID");
        }


        [Test, Order (8)]
        public void Test_EditCommentOnGitHubIssue()
        {
            //Arrange
            int commentId = 2045168289;
            string newBody = "This is the updated text of the comment";
            //Act
            var comment = client.EditCommentOnGitHubIssue(repo, commentId, newBody);
            //Assert
            Assert.That(comment, Is.Not.Null);
            Assert.That(comment.Id, Is.EqualTo(commentId), "The updatet comment ID should match the original comment ID");
            Assert.That(comment.Body, Is.EqualTo(newBody), "The updated comment text should match the new body text.");
        }


        [Test, Order (9)]
        public void Test_DeleteCommentOnGitHubIssue()
        {
            //Arrange
            int commentId = 2045168289;
            //Act
            var result = client.DeleteCommentOnGitHubIssue(repo, commentId);
            //Assert
            Assert.That(result, Is.True);
        }


    }
}

