﻿namespace CarBook.DTO.ContactDtos
{
    public class ResultContactDto
    {
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string EMail { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime SendDate { get; set; }
    }
}
