import {TransactionApi, ApiTransactionEmployeeEmployeeIdGetRequest} from '../SemesApi';
import { combineReducers, createStore } from 'redux';
import { ofType, combineEpics, createEpicMiddleware } from 'redux-observable';
import { map, flatMap } from 'rxjs/operators';
import { ajax } from 'rxjs/ajax';

let transactionHistoryApi = new TransactionApi();
const transactionHistoryReducerEpic = (action$:any) => 
    action$.pipe(
        ofType('UPDATE_TRANSACTIONS'),
        () => transactionHistoryApi.apiTransactionEmployeeEmployeeIdGet({employeeId:"dfghj"}),
        map(transactions => ({ 
            type: 'UPDATE_TRANSACTIONS_SUCCESS', 
            payload: transactions 
        }))
);

const rootEpic = combineEpics(transactionHistoryReducerEpic);
export default rootEpic;