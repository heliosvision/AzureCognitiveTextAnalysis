using Microsoft.ProjectOxford.Text.KeyPhrase;
using Microsoft.ProjectOxford.Text.Sentiment;
using System;

namespace TextAnalyticsSampleClient
{
    class Program
    {
        static void Main(string[] args)
        {

            // MS Cognitive Services API key
            var apiKeyTextAnalytics = "REPLACE_WITH_API_KEY";

            var text = @"A thing of beauty is a joy for ever:
                        Its loveliness increases; it will never
                        Pass into nothingness; but still will keep
                        A bower quiet for us, and a sleep
                        Full of sweet dreams, and health, and quiet breathing.";
                
            // GET text sentiment
            var sentimentDocument = new SentimentDocument()
            {
                Id = "Sentiment",
                Text = text,
                Language = "en"
            };

            Console.WriteLine("Analyzing {0}", sentimentDocument.Id + "..");

            var sentimentRequest = new SentimentRequest();
            sentimentRequest.Documents.Add(sentimentDocument);
            var sentimentClient = new SentimentClient(apiKeyTextAnalytics);
            var sentimentResponse = sentimentClient.GetSentiment(sentimentRequest);

            Console.WriteLine("   Score: {0}%", (sentimentResponse.Documents[0].Score * 100) + " [0% - negative, 100% - positive]");

            // GET text keyphrases
            var keyPhraseDocument = new KeyPhraseDocument()
            {
                Id = "KeyPhrases",
                Text = text,
                Language = "en"
            };

            Console.WriteLine("Recognizing {0}", keyPhraseDocument.Id + "..");

            var keyPhraseRequest = new KeyPhraseRequest();
            keyPhraseRequest.Documents.Add(keyPhraseDocument);
            var keyPhraseClient = new KeyPhraseClient(apiKeyTextAnalytics);
            var keyPhraseResponse = keyPhraseClient.GetKeyPhrases(keyPhraseRequest);

            foreach (var keyPhrase in keyPhraseResponse.Documents[0].KeyPhrases)
            {
                Console.WriteLine("   KeyPhrase: {0}", keyPhrase);
            }
        }
    }
}
