/**
 * @module Image
 * @submodule Image
 * @for p5
 * @requires core
 */

/**
 * @method createImage
 * @param  {Integer} width  width in pixels
 * @param  {Integer} height height in pixels
 * @return {p5.Image}       the <a href="#/p5.Image">p5.Image</a> object
 */


/**
 *  Save the current canvas as an image. The browser will either save the
 *  file immediately, or prompt the user with a dialogue window.
 *
 *  @method saveCanvas
 *  @param  {p5.Element|HTMLCanvasElement} selectedCanvas   a variable
 *                                  representing a specific html5 canvas (optional)
 *  @param  {String} [filename]
 *  @param  {String} [extension]      'jpg' or 'png'
 *
 */
/**
 *  @method saveCanvas
 *  @param  {String} [filename]
 *  @param  {String} [extension]
 */


/**
 *  @method saveFrames
 *  @param  {String}   filename
 *  @param  {String}   extension 'jpg' or 'png'
 *  @param  {Number}   duration  Duration in seconds to save the frames for.
 *  @param  {Number}   framerate  Framerate to save the frames in.
 *  @param  {function(Array)} [callback] A callback function that will be executed
                                  to handle the image data. This function
                                  should accept an array as argument. The
                                  array will contain the specified number of
                                  frames of objects. Each object has three
                                  properties: imageData - an
                                  image/octet-stream, filename and extension.
 
 */
