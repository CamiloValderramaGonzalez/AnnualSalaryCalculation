import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { actionCreators } from '../store/Employee';
import { Link } from 'react-router-dom';

class Employee extends Component {
    constructor(props) {
        super(props);
        this.state = { id: "" }
    }

    componentWillUnmount() {
        this.props.requestEmployee(-1);
    }

    onChange = (e) => {
        var reg = new RegExp('[0-9]$');
        if (reg.test(e.target.value) || e.target.value === "")
            this.setState({ id: e.target.value });
    }
    onClick = (e) => {
        this.props.requestEmployee(this.state.id);
    }
    render() {
        return (
            <div className="pr-4">
                {(this.props.isLoading ?
                    <div className="loading">
                        <div className="loader">
                        </div >
                    </div> : <div></div>)}
                <h1>Employees Salary</h1>
                <div className="form-group">
                    <label htmlFor="employeeId">Employee Id</label>
                    <input type="text" maxLength="9" className="form-control" id="employeeId"
                        placeholder="Enter Employee id"
                        value={this.state.id}
                        onChange={this.onChange} />
                </div>
                <div className="form-group">
                    <button className="btn btn-primary btn-sm" onClick={this.onClick}>Get Employees</button>
                </div>
                <div className="form-group">
                    <label className="form-group p-3">Calculated Annual Salary</label>
                    {renderForecastsTable(this.props)}
                </div>
            </div>
        );
    }
}

function renderForecastsTable(props) {
    return (
        <table className='table'>
            <thead>
                <tr>
                    <th>Id</th>
                    <th>Name</th>
                    <th>Role Name</th>
                    <th>Contract Type</th>
                    <th className="text-right">Annual Salary</th>
                </tr>
            </thead>
            <tbody>
                {props.employee && props.employee.length > 0 ? props.employee.map(employee =>
                    <tr key={employee.id}>
                        <td>{employee.id}</td>
                        <td>{employee.name}</td>
                        <td>{employee.roleName}</td>
                        <td>{employee.contractTypeName}</td>
                        <td className="text-right">{employee.annualSalary.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ".")}</td>
                    </tr>
                ) : <tr key={"noId"}><td colSpan="5" className="text-center">No Results</td></tr>}
            </tbody>
        </table>    
    );
}

export default connect(
    state => state.employee,
    dispatch => bindActionCreators(actionCreators, dispatch)
)(Employee);
