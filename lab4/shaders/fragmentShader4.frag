varying vec2 vUv;
uniform sampler2D texture4;
vec4 color;


void main() {
  
  float scale = 5.0;


  gl_FragColor = texture2D(texture4, mod(vUv,(1.0/scale))*scale);

}
