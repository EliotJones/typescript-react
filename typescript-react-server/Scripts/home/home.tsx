import ReactDOM = require("react-dom");
import { ResultsGrid } from "./resultsGrid";
import * as React from "react";

function render() {
    ReactDOM.render(<ResultsGrid url="/Home/GetData" />,
        document.getElementById("content"));
}

render();
