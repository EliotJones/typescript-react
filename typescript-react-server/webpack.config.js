module.exports = {
    entry: "./scripts/home/home.tsx",
    output: {
        filename: "./wwwroot/js/bundle.js"
    },
    devtool: "source-map",
    resolve: {
        extensions: ["", ".webpack.js", ".web.js", ".ts", ".js", ".tsx" ]
    },
    module: {
        loaders: [
          { test: /\.ts$/, loader: "ts-loader" },
          { test: /\.tsx$/, loader: "ts-loader" }
        ],
        preLoaders: [
            { test: /\.js$/, loader: "source-map-loader" }
        ]
    },
    externals: {
        "react": "React",
        "react-dom": "ReactDOM",
        "jquery": "jQuery"
    }
}