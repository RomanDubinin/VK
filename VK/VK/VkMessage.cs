namespace VK
{
	class VkMessage
	{
		public int MessageId { get; private set; }
		public int PersonId { get; private set; }
		public string Body { get; private set; }
		public bool IsInChat { get; private set; }

		public VkMessage(int personId, int messageId, string body, bool isInChat = false)
		{
			MessageId = messageId;
			PersonId = personId;
			Body = body;
			IsInChat = isInChat;
		}
	}
}