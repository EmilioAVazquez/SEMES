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
import { BaseAPI, HttpHeaders, throwIfNullOrUndefined, encodeURI } from '../runtime';
import {
    Client,
} from '../models';

export interface ApiClientClientsKeyGetRequest {
    key: string | null;
}

export interface ApiClientEmployeeIdGetRequest {
    id: string | null;
}

export interface ApiClientIdDeleteRequest {
    id: string | null;
}

export interface ApiClientIdGetRequest {
    id: string | null;
}

export interface ApiClientPostRequest {
    client?: Client;
}

export interface ApiClientPutRequest {
    client?: Client;
}

/**
 * no description
 */
export class ClientApi extends BaseAPI {

    /**
     * Gets a List of possible Clients by phone number string or a firstName_Lastname string
     */
    apiClientClientsKeyGet = ({ key }: ApiClientClientsKeyGetRequest): Observable<Array<Client>> => {
        throwIfNullOrUndefined(key, 'apiClientClientsKeyGet');

        return this.request<Array<Client>>({
            path: '/api/Client/clients/{key}'.replace('{key}', encodeURI(key)),
            method: 'GET',
        });
    };

    /**
     * Gets a list of the most frequently used products by Employee.
     */
    apiClientEmployeeIdGet = ({ id }: ApiClientEmployeeIdGetRequest): Observable<Array<Client>> => {
        throwIfNullOrUndefined(id, 'apiClientEmployeeIdGet');

        return this.request<Array<Client>>({
            path: '/api/Client/employee/{id}'.replace('{id}', encodeURI(id)),
            method: 'GET',
        });
    };

    /**
     * Deletes a Client entity by its id. Valid clientId required.
     */
    apiClientIdDelete = ({ id }: ApiClientIdDeleteRequest): Observable<void> => {
        throwIfNullOrUndefined(id, 'apiClientIdDelete');

        return this.request<void>({
            path: '/api/Client/{id}'.replace('{id}', encodeURI(id)),
            method: 'DELETE',
        });
    };

    /**
     * Gets a Client entity by its id.
     */
    apiClientIdGet = ({ id }: ApiClientIdGetRequest): Observable<Client> => {
        throwIfNullOrUndefined(id, 'apiClientIdGet');

        return this.request<Client>({
            path: '/api/Client/{id}'.replace('{id}', encodeURI(id)),
            method: 'GET',
        });
    };

    /**
     * Updates a given Client entity. Valid clientId required.
     */
    apiClientPost = ({ client }: ApiClientPostRequest): Observable<void> => {

        const headers: HttpHeaders = {
            'Content-Type': 'application/json',
        };

        return this.request<void>({
            path: '/api/Client',
            method: 'POST',
            headers,
            body: client,
        });
    };

    /**
     * Adds a new Client entity with dummy id and returns same Client enity BUT with   updated id.
     */
    apiClientPut = ({ client }: ApiClientPutRequest): Observable<void> => {

        const headers: HttpHeaders = {
            'Content-Type': 'application/json',
        };

        return this.request<void>({
            path: '/api/Client',
            method: 'PUT',
            headers,
            body: client,
        });
    };

}
