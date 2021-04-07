import React from "react";
import image from '../../images/404.png'

const ErrorPage = () => {
    return (
        <div>
            <div>The page you're looking for is missing. Please double-check the url or contact our administrators! </div>;
            <img alt="" src={image}></img>
        </div>
    )
}

export default ErrorPage