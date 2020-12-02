import React from 'react';
import { connect } from 'react-redux';

const Home = props => (
    <div>
        <h1>Welcome to Annual Salary Calculation!</h1>
        <p>In this web-application, you can calculate the annual salary of employees</p>
        <strong>You can calculate Annual Salary for: </strong>
        <ul>
            <li>Hourly Salary Contract</li>
            <li>Monthly Salary Contract</li>
        </ul>
    </div>
);

export default connect()(Home);
