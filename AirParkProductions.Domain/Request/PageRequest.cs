namespace AirParkProductions.Domain.Request
{
    public record PageRequest(int PageNumber = 1, int PageSize = 10);

    public static class PageRequestExtension
    {
        public static int LineToSkip(this PageRequest pageRequest)
        {
            return pageRequest.PageNumber > 1 ? (pageRequest.PageNumber - 1) * pageRequest.PageSize : 0;
        }
    }
}
