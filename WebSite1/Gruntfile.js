//包装函数
module.exports = function(grunt) {

    var serveStatic = require('serve-static');
    var serveIndex = require('serve-index');
    // LiveReload的默认端口号，你也可以改成你想要的端口号
    var lrPort = 35729;
    // 使用connect-livereload模块，生成一个与LiveReload脚本
    // <script src="http://127.0.0.1:35729/livereload.js?snipver=1" type="text/javascript"></script>
    var lrSnippet = require('connect-livereload')({ port: lrPort });
    // 使用 middleware(中间件)，就必须关闭 LiveReload 的浏览器插件
    var lrMiddleware = function(connect, options) {
        return [
            // 把脚本，注入到静态文件中
            lrSnippet,
            // 静态文件服务器的路径
            connect.static(options.base[0]),

            // 启用目录浏览(相当于IIS中的目录浏览)
            connect.directory(options.base[0])
        ];
    };

    var lrMiddleware2 = function(connect, options) {
        return [
            // 把脚本，注入到静态文件中
            lrSnippet,
            // 静态文件服务器的路径
            serveStatic(options.base[0]),
           // connect.static(options.base[0]),
            // 启用目录浏览(相当于IIS中的目录浏览)
          //  connect().use('/bower_components', serveStatic('./bower_components')),
            serveIndex(options.base[0])
           // connect.directory(options.base[0])
        ];
    };



    //任务配置，所有插件的配置信息
    grunt.initConfig({
        //获取 package.json的信息
        pkg: grunt.file.readJSON('package.json'),

        //uglify插件的配置信息
        uglify: {
            options: {
                stripBanners: true,
                banner: '/*! <%=pkg.name%>-<%=pkg.version%>.js <%= grunt.template.today("yyyy-mm-dd") %> */\n'
            },
            build: {
                src: 'static/js/index.js',
                dest: 'build/js/index-<%=pkg.version%>.js.min.js'
            }
        },
        jshint:{
            backend: {
                options: {
                    jshintrc: '.jshintrc'
                },
                all: [
                    'Gruntfile.js',
                    'server.js',
                    '*.js',
                    'backend/{,*/}*.js'
                ]
            },
            test: {
                options: {
                    jshintrc: 'test.jshintrc'
                },
                all: [
                    'test/{,*/}*.js'
                ]
            }
        },
        connect: {
            options: {
                // 服务器端口号
                port: 8000,
                // 服务器地址(可以使用主机名localhost，也能使用IP)
                hostname: 'localhost',
                // 物理路径(默认为. 即根目录) 注：使用'.'或'..'为路径的时，可能会返回403 Forbidden. 此时将该值改为相对路径 如：/grunt/reloard。
                base: '.'
            },
            livereload: {
                options: {
                    // 通过LiveReload脚本，让页面重新加载。
                    middleware: lrMiddleware2
                }
            }
        },
        watch: {
            build: {
                files: ['static/js/*.js', 'static/css/*.css','js/*.js'],
                tasks: ['jshint', 'uglify'],
                options: {spawn: false}
            },
            client: {
                // 我们不需要配置额外的任务，watch任务已经内建LiveReload浏览器刷新的代码片段。
                options: {
                    livereload: lrPort
                },
                // '**' 表示包含所有的子目录
                // '*' 表示包含所有的文件
                files: ['*.html', 'css/*', 'js/*', 'images/**/*']
            }
        }
    });
    //告诉grunt我们将使用的插件
    grunt.loadNpmTasks('grunt-contrib-uglify');
    grunt.loadNpmTasks('grunt-contrib-jshint');
    grunt.loadNpmTasks('grunt-contrib-connect');
    grunt.loadNpmTasks('grunt-contrib-watch');

    //告诉grunt当我们在终端输入grunt时需要做些什么（注意先后顺序）
    grunt.registerTask('default', ['jshint','uglify','watch']);
    grunt.registerTask('live', ['connect', 'watch']);
};