import { AuthorType } from "./author.model";
import { GenreType } from "./genre.model";
import { ReviewType } from "./review.model";

export type BookType = {
    id?: number;
    title:string;
    authors:AuthorType[];
    reviews?:ReviewType[];
    genres: GenreType[];
    image:string;
    description: string;
}


export type BookPostType = {
    title:string;
    authorsId:number[];
    genresId: number[];
    image:string;
    description: string;
}