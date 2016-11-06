import * as React from "react";
import * as $ from "jquery";

export interface ResultsGridProps {
    url: string
}

export interface ResultsGridState {
    data: Label;
}

export interface Label {
    name: string;
    rappers: Rapper[];
}

export interface Rapper {
    name: string;
    realName: string;
    age: number;
}

export class ResultsGrid extends React.Component<ResultsGridProps, any>{
    constructor(props: ResultsGridProps) {
        super(props);

        this.state = {

        };
    }

    handleKeyDown(e: any) {
        console.log(e.keyCode);
    }

    componentDidMount() {
        $.getJSON(this.props.url, data => {
            console.log(data);
            this.setState({ data: data });
        });
    }

    public render() {
        console.log("alp");

        var labels = [];

        if (this.state.data != undefined) {
            labels.push(<LabelDisplay data={this.state.data}/>);
        }

        return (
            <div>
                <div className="title">
                    <h1>Results</h1>
                    <input
                        ref="filterInput"
                        onKeyDown={e => this.handleKeyDown(e)}>
                    </input>
                </div>
                <div className="results">
                    {labels}
                </div>
            </div>)
    }
}

export class LabelDisplay extends React.Component<any, any>{
    constructor(props: any) {
        super(props);
    }

    public render() {
        console.log("Render");

        return (<h2>{this.props.data.name}</h2>);
    }
}