import { User } from './../Modelos/User';
export interface Activity{
    id?: number;
    activityName?: string;
    createDate?: Date;
    idUser?: number;
    user?: User;
    

}