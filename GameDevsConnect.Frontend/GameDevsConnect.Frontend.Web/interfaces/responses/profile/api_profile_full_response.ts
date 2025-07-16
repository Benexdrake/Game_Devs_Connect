import { IUser } from "@/interfaces/user";
import { IAPIResponse } from "../api_response";
import { IProfile } from "@/interfaces/profile";

export interface IAPIProfileFullResponse extends IAPIResponse
{
    user:IUser;
    profile:IProfile;
    followerCount:number;
    followingCount:number;
}