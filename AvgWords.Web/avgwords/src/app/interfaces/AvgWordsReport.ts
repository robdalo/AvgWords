export interface AvgWordsReport {
  artist: string;
  numberOfSongs: number;
  numberOfWords: number;
  averageWordsPerSong: number;
  songs: Map<string, number>;
  errorMessage: string;
}
