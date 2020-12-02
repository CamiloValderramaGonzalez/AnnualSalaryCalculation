const requestEmployeeType = 'REQUEST_EMPLOYEE';
const receiveEmployeeType = 'RECEIVE_EMPLOYEE';
const initialState = { employee: [], isLoading: false };

export const actionCreators = {
    requestEmployee: id => async (dispatch, getState) => {
        if (id === getState().employee.id) {
            // Don't issue a duplicate request (we already have or are loading the requested data)
            return;
        }

        dispatch({ type: requestEmployeeType, id });

        const url = "api/Employee" + (id ? "/" + id : "");
        const response = await fetch(url);
        const employee = await response.json();

        dispatch({ type: receiveEmployeeType, id, employee });
    }
};

export const reducer = (state, action) => {
    state = state || initialState;

    if (action.type === requestEmployeeType) {
        return {
            ...state,
            id: action.id,
            isLoading: true
        };
    }

    if (action.type === receiveEmployeeType) {
        if (action.id === state.id)
            return {
                ...state,
                id: action.id,
                employee: action.employee,
                isLoading: false
            };
    }

    return state;
};
