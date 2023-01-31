import { BookType } from "./book.model";

export type GenreType = {
    id: number;
    name: string;
    books:BookType[];
}