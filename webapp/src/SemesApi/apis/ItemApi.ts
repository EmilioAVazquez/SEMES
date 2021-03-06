// tslint:disable
/**
 * ToDo API
 * A simple example ASP.NET Core Web API
 *
 * The version of the OpenAPI document: v1
 * 
 *
 * NOTE: This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */

import { Observable } from 'rxjs';
import { BaseAPI, throwIfNullOrUndefined, encodeURI } from '../runtime';
import {
    Item,
} from '../models';

export interface ApiItemIdGetRequest {
    id: string | null;
}

/**
 * no description
 */
export class ItemApi extends BaseAPI {

    /**
     */
    apiItemIdGet = ({ id }: ApiItemIdGetRequest): Observable<Item> => {
        throwIfNullOrUndefined(id, 'apiItemIdGet');

        return this.request<Item>({
            path: '/api/Item/{id}'.replace('{id}', encodeURI(id)),
            method: 'GET',
        });
    };

}
