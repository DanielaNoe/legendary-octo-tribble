import { ArticleViewModel } from "./ArticleViewModel";

export interface PositionViewModel { 
    id: string;
    amount: number;
    article: ArticleViewModel;
    price: number;
    totalPrice: number;
}