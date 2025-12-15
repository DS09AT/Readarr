export interface Author {
  id: number;
  authorName: string;
  sortName: string;
  titleSlug: string;
  authorNameLastFirst: string;
  overview?: string;
  status: 'continuing' | 'ended';
  tags: number[];
  images: AuthorImage[];
  path: string;
  monitored: boolean;
  added: string;
  genres: string[];
  ratings: {
    votes: number;
    value: number;
    popularity: number;
  };
  statistics: {
    bookCount: number;
    bookFileCount: number;
    sizeOnDisk: number;
    percentOfBooks: number;
  };
}

export interface AuthorImage {
  coverType: string;
  url: string;
  remoteUrl: string;
}
