import TransactionHistoryReducer from './TransactionHistory';
import {combineReducers} from 'redux';

const allReducers = combineReducers({
    TransactionHistory : TransactionHistoryReducer
});

export default allReducers;