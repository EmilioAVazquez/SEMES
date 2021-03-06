import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App';
import * as serviceWorker from './serviceWorker';
import allReducers from './Reducer';
import {Provider} from 'react-redux';
import rootEpic from './Epic';
import {  createStore, applyMiddleware , compose} from 'redux'
import { ofType, combineEpics, createEpicMiddleware } from 'redux-observable';
import { Action } from 'rxjs/internal/scheduler/Action';

const epicMiddleware = createEpicMiddleware();
const composeEnhancers = (window as any).__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ || compose;
const store = createStore(
  allReducers,
  composeEnhancers(
    applyMiddleware(epicMiddleware))
  );
epicMiddleware.run(rootEpic);
ReactDOM.render(
  <React.StrictMode>
    <Provider store={store}>
      <App />
    </Provider >
  </React.StrictMode>,
  document.getElementById('root')
);

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.unregister();
