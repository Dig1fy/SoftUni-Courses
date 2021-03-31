import React from 'react'

class ErrorBoundary extends React.Component {
    constructor(props) {
        super(props)

        this.state = ({ isThereAnError: false })
    }

    static getDerivedStateFromError(error) {
        return { isThereAnError: true }
    }

    componentDidCatch(error, info) {
        console.log("New error occured in componentDidCatch:", error, info);
    }

    render() {
        if (this.state.isThereAnError) {
            <div>{"Something went wrong (error boundary)"}</div>
        }

        return this.props.children
    }
}

export default ErrorBoundary