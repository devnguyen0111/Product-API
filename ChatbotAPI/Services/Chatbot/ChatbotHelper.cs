using EduConnect.Domain.Entities;
using Microsoft.Extensions.AI;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.Ollama;
using System.Runtime.CompilerServices;

namespace EduConnect.ChatbotAPI.Services.Chatbot
{
    public class ChatbotHelper
    {
        ChatHistory chatHistory = new ChatHistory();

        private readonly Kernel _kernel;
        private readonly HttpClient _httpClient;


        public ChatbotHelper(Kernel kernel, HttpClient httpClient)
        {
            _kernel = kernel;
            _httpClient = httpClient;

        }


        public async IAsyncEnumerable<string> ChatbotResponseAsync(string userPrompt, Guid conversationId, [EnumeratorCancellation] CancellationToken ct = default)
        {

            //chatHistory = await _chatbotStorage.GetChatHistory(conversationId);
            IChatCompletionService chatCompletionService = _kernel.GetRequiredService<IChatCompletionService>();
            string response = string.Empty; 

            //Them prompt nguoi dung vao chat history
            chatHistory.Add(new ChatMessageContent(AuthorRole.User, userPrompt));

            #pragma warning disable SKEXP0070
            OllamaPromptExecutionSettings ollamaPromptExecutionSettings = new()
            {
                FunctionChoiceBehavior = FunctionChoiceBehavior.Auto(),
                ModelId = "qwen3:0.6b",
            };

            await foreach (var item in chatCompletionService.GetStreamingChatMessageContentsAsync(chatHistory, ollamaPromptExecutionSettings, _kernel, ct))
            {
                response += item;
                yield return response;
            }

        }
    }
}
