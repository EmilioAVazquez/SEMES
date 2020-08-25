import transactionHistoryReducer from './transactionHistoryReducer';
import {combineReducers} from 'redux';

const allReducers = combineReducers({
    transactionHistory : transactionHistoryReducer
});

export default allReducers;