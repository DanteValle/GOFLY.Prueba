import { Item } from './Item';
export interface Sale{
    id?: number;
    client: string;
    listItems?:Item[];
    totalItems?:number;
    description?: string;
    totalPrice? : any;
}