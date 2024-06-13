namespace nexus.Config.Response
{
    public class Response<T>
    {
        public string Message { get; set; }
        public T Data { get; set; }
        public bool Success { get; set; }
        public int LastPage { get; set; }
        public int TotalData { get; set; }

        public Response<T> ToJson()
        {
            var response = new Response<T>
            {
                Message = this.Message,
                Data = this.Data,
                Success = this.Success,
                LastPage = this.LastPage,
                TotalData = this.TotalData
            };

            this.Clear();

            return response;
        }

        private void Clear()
        {
            this.Message = null;
            this.Data = default(T);
            this.Success = false;
            this.LastPage = 0;
            this.TotalData = 0;
        }
    }
}
