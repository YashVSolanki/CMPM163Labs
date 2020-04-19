varying vec3 vUv;

uniform vec3 colorA;
uniform vec3 colorB;
uniform vec3 colorC;
uniform float time;
void main() {
  vec3 AB = vec3(mix(colorA, colorB, abs(sin(time)+vUv.x))/1.5);
  vec3 BC = vec3(mix(colorB, colorC, abs(cos(time)+vUv.y))/1.5);
  gl_FragColor = vec4(mix(AB, BC, abs(sin(time)+vUv.z))/1.5,1.0);
}
