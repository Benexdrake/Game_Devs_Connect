import { IUser } from "../../user";
import { IAPIResponse } from "../api_response";

export interface IAPIUserResponse extends IAPIResponse
{
    user: IUser;
}