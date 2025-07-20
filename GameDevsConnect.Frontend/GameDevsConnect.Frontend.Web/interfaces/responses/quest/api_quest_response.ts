import { IQuest } from "../../quest";
import { IAPIResponse } from "../api_response";

export interface IAPIQuestResponse extends IAPIResponse
{
    quest:IQuest;
    favoritedQuest:boolean;
}