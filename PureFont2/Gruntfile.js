/*包装函数*/
module.exports=function (grunt) {
    grunt.initConfig({
        //获取package.json信息
        pkg:grunt.file.readJSON('package.json')
    });
    //告诉grunt当我们在终端中输入grunt时需要做些什么（注意先后顺序）
    grunt.registerTask('default',[]);
};