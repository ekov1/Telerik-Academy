(function() {
    'use strict';

    var http = require('http');

    var formidable = require('formidable');
    var util       = require('util');
    var fse         = require('fs-extra');
    var uuid = require('uuid');
    var jade = require('jade');

    http.createServer(function (req, res) {
        if (req.url === '/upload' && req.method.toLowerCase() == 'post') {
            var form = new formidable.IncomingForm();

            form.parse(req, function (err, fields, files) {
                fse.readFile('./views/upload-form-success.html', function(err, html) {
                    if (err) {
                        res.end(err);
                    } else {
                        res.writeHead(200, {'content-type': 'text/html'});
                        res.write(html);
                        res.end();
                    }
                });
            });

            form.on('end', function(fields, files) {
                var temp_path = this.openedFiles[0].path;
                var file_name = this.openedFiles[0].name;
                var file_extension = file_name.substring(file_name.lastIndexOf('.')).toLowerCase();
                var new_location = './uploaded_files';
                var new_name = uuid.v4();
                fse.copy(temp_path, new_location + '/' + new_name + file_extension, function(err) {
                    if (err) {
                        console.log(err);
                    } else {
                        console.log('File uploaded successfully');
                    }
                })
            });

            return;
        }

        if (req.url === '/') {
            fse.readFile('./views/upload-form.html', function(err, html) {
                if (err) {
                    console.log(err);
                } else {
                    res.writeHead(200, {'content-type': 'text/html'});
                    res.write(html);
                    res.end();
                }
            });
        }

        if (req.url === '/files') {
            fse.readFile('./views/all-files.jade', function(err, template) {
                if (err) {
                    res.end(err);
                } else {
                    fse.readdir('./uploaded_files/', function(err, files) {
                        if (err) {
                            res.end(err);
                        } else {
                            var view = jade.compile(template)({
                                files: files
                            });

                            res.write(view);
                            res.end();
                        }
                    })
                }
            });
        }

        if (req.url.indexOf('file') && req.url.split('/').length === 3) {
            var params = req.url.split('/');
            var guid = params[params.length-1];

            fse.readdir('./uploaded_files/', function (err, files) {
                for (var i = 0, len = files.length; i < len; i += 1) {
                    var fileName = files[i];

                    if (guid === fileName) {

                        res.writeHead(200, {
                            'Content-Disposition': 'attachment; filename=' + files[i] + ';'
                        });

                        var readStream = fse.createReadStream('./uploaded_files/' + files[i]);
                        readStream.pipe(res);
                        return;
                    }
                }

                res.end('<p>File not found!</p>');

            });
        }

    }).listen(4212);

    console.log('Server is running on port ' + 4212);
}());