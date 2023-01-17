namespace MovieDatabase.Core.Models
{
    public class Movie
    {
        public virtual string? Title { get; set; }
        public virtual string? Year { get; set; }
        public virtual string? Rated { get; set; }
        public virtual string?Released { get; set; }
        public virtual string? Runtime { get; set; }
        public virtual string? Genre { get; set; }
        public virtual string? Director { get; set; }
        public virtual string? Writer { get; set; }
        public virtual string? Actors { get; set; }
        public virtual string? Plot { get; set; }
        public virtual string? Language { get; set; }
        public virtual string? Country { get; set; }
        public virtual string? Awards { get; set; }
        public virtual string? Poster { get; set; }
        public virtual Rating[]? Ratings { get; set; }
        public virtual string? Metascore { get; set; }
        public virtual string? imdbRating { get; set; }
        public virtual string? imdbVotes { get; set; }
        public virtual string? imdbID { get; set; }
        public virtual string? Type { get; set; }
        public virtual string? DVD { get; set; }
        public virtual string? BoxOffice { get; set; }
        public virtual string? Production { get; set; }
        public virtual string? Website { get; set; }
        public virtual string? Response { get; set; }
    }

    public class Rating
    {
        public virtual string? Source { get; set; }
        public virtual string? Value { get; set; }
    }
}
