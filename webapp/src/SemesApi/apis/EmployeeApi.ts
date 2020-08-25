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
    Employee,
} from '../models';

export interface ApiEmployeeIdDeleteRequest {
    id: string | null;
}

export interface ApiEmployeeIdGetRequest {
    id: string | null;
}

export interface ApiEmployeePostRequest {
    employee?: Employee;
}

export interface ApiEmployeePutRequest {
    employee?: Employee;
}

/**
 * no description
 */
export class EmployeeApi extends BaseAPI {

    /**
     * Deletes a Admi entity by its id. Valid employeeId required.
     */
    apiEmployeeIdDelete = ({ id }: ApiEmployeeIdDeleteRequest): Observable<void> => {
        throwIfNullOrUndefined(id, 'apiEmployeeIdDelete');

        return this.request<void>({
            path: '/api/Employee/{id}'.replace('{id}', encodeURI(id)),
            method: 'DELETE',
        });
    };

    /**
     * Gets a Employee entity by its id.
     */
    apiEmployeeIdGet = ({ id }: ApiEmployeeIdGetRequest): Observable<Employee> => {
        throwIfNullOrUndefined(id, 'apiEmployeeIdGet');

        return this.request<Employee>({
            path: '/api/Employee/{id}'.replace('{id}', encodeURI(id)),
            method: 'GET',
        });
    };

    /**
     * Updates a given Employee entity. Valid employeeId required.
     */
    apiEmployeePost = ({ employee }: ApiEmployeePostRequest): Observable<void> => {

        const headers: HttpHeaders = {
            'Content-Type': 'application/json',
        };

        return this.request<void>({
            path: '/api/Employee',
            method: 'POST',
            headers,
            body: employee,
        });
    };

    /**
     * Adds a Employee entity by its id.
     */
    apiEmployeePut = ({ employee }: ApiEmployeePutRequest): Observable<Employee> => {

        const headers: HttpHeaders = {
            'Content-Type': 'application/json',
        };

        return this.request<Employee>({
            path: '/api/Employee',
            method: 'PUT',
            headers,
            body: employee,
        });
    };

}
