"use client"; // Make sure this is at the very top if you need interactivity

import { Button } from "@/components/ui/button"
import { Card, CardContent, CardDescription, CardHeader, CardTitle } from "@/components/ui/card"
import { Badge } from "@/components/ui/badge"
import { Input } from "@/components/ui/input"
import { BookOpen, Star, Truck, Shield, Users, Zap } from "lucide-react"
import Image from "next/image"
import Link from "next/link"

export default function ComicStoreLanding() {
  return ( // <--- ENSURE YOU HAVE THIS OPENING PARENTHESIS
    <div className="flex flex-col min-h-screen bg-gradient-to-br from-gray-900 via-slate-900 to-black">
      {/* Header */}
      <header className="px-4 lg:px-6 h-16 flex items-center border-b border-gray-800 bg-gray-900/80 backdrop-blur-sm sticky top-0 z-50">
        <Link href="/" className="flex items-center justify-center">
          <BookOpen className="h-8 w-8 text-purple-600" />
          <span className="ml-2 text-2xl font-bold bg-gradient-to-r from-cyan-400 to-purple-400 bg-clip-text text-transparent">
            ComicVerse
          </span>
        </Link>
        <nav className="ml-auto flex gap-4 sm:gap-6">
          <Link href="http://localhost:5170" className="text-sm font-medium text-gray-300 hover:text-cyan-400 transition-colors">
            Comics
          </Link>
          <Link href="#manga" className="text-sm font-medium text-gray-300 hover:text-cyan-400 transition-colors">
            Manga
          </Link>
          <Link
            href="#coleccionables"
            className="text-sm font-medium text-gray-300 hover:text-cyan-400 transition-colors"
          >
            Coleccionables
          </Link>
          <Link href="#ofertas" className="text-sm font-medium text-gray-300 hover:text-cyan-400 transition-colors">
            Ofertas
          </Link>
          <Link href="#contacto" className="text-sm font-medium text-gray-300 hover:text-cyan-400 transition-colors">
            Contacto
          </Link>
        </nav>
      </header>

      <main className="flex-1">
        {/* Hero Section */}
        <section className="w-full py-12 md:py-24 lg:py-32 relative overflow-hidden">
          <div className="absolute inset-0 bg-gradient-to-r from-cyan-500/20 to-purple-500/20"></div>
          <div className="container px-4 md:px-6 relative">
            <div className="grid gap-6 lg:grid-cols-[1fr_400px] lg:gap-12 xl:grid-cols-[1fr_600px]">
              <div className="flex flex-col justify-center space-y-4">
                <div className="space-y-2">
                  <Badge className="bg-gray-800 text-cyan-400 hover:bg-gray-700">
                    ¡Nuevos lanzamientos cada semana!
                  </Badge>
                  <h1 className="text-3xl font-bold tracking-tighter sm:text-5xl xl:text-6xl/none bg-gradient-to-r from-cyan-400 to-purple-400 bg-clip-text text-transparent">
                    Tu universo de comics favorito
                  </h1>
                  <p className="max-w-[600px] text-gray-300 md:text-xl">
                    Descubre la colección más completa de comics, manga y coleccionables. Desde clásicos atemporales
                    hasta los últimos lanzamientos.
                  </p>
                </div>
                <div className="flex flex-col gap-2 min-[400px]:flex-row">
                  <Button
                    size="lg"
                    className="bg-gradient-to-r from-cyan-600 to-purple-600 hover:from-cyan-700 hover:to-purple-700"
                    onClick={() => window.location.href = 'http://localhost:5170'}
                  >
                    Explorar Catálogo
                  </Button>
                  <Button variant="outline" size="lg" className="border-gray-600 hover:bg-gray-800 text-gray-300">
                    Ver Ofertas
                  </Button>
                </div>
                <div className="flex items-center gap-4 text-sm text-gray-400">
                  <div className="flex items-center gap-1">
                    <Star className="h-4 w-4 fill-yellow-400 text-yellow-400" />
                    <span className="font-medium">4.9/5</span>
                    <span>(2,847 reseñas)</span>
                  </div>
                  <div className="flex items-center gap-1">
                    <Truck className="h-4 w-4" />
                    <span>Envío gratis desde $50</span>
                  </div>
                </div>
              </div>
              <div className="flex items-center justify-center">
                <div className="relative">
                  <div className="absolute inset-0 bg-gradient-to-r from-purple-400 to-blue-400 rounded-2xl blur-2xl opacity-30"></div>
                  <Image
                    src="/placeholder.svg?height=500&width=400"
                    width={400}
                    height={500}
                    alt="Comics Hero"
                    className="relative rounded-2xl shadow-2xl"
                  />
                </div>
              </div>
            </div>
          </div>
        </section>

        {/* Categories Section */}
        <section className="w-full py-12 md:py-24 lg:py-32 bg-gray-900">
          <div className="container px-4 md:px-6">
            <div className="flex flex-col items-center justify-center space-y-4 text-center">
              <div className="space-y-2">
                <h2 className="text-3xl font-bold tracking-tighter sm:text-5xl">Explora nuestras categorías</h2>
                <p className="max-w-[900px] text-gray-300 md:text-xl/relaxed lg:text-base/relaxed xl:text-xl/relaxed">
                  Encuentra exactamente lo que buscas en nuestra amplia selección
                </p>
              </div>
            </div>
            <div className="mx-auto grid max-w-5xl items-center gap-6 py-12 lg:grid-cols-3 lg:gap-8">
              <Card className="group hover:shadow-lg transition-all duration-300 bg-gray-800 border-gray-700 hover:border-gray-600">
                <CardHeader className="text-center">
                  <div className="mx-auto mb-4 h-16 w-16 rounded-full bg-gradient-to-r from-red-400 to-pink-400 flex items-center justify-center">
                    <Zap className="h-8 w-8 text-white" />
                  </div>
                  <CardTitle className="text-xl">Superhéroes</CardTitle>
                  <CardDescription>Marvel, DC Comics y más universos épicos</CardDescription>
                </CardHeader>
                <CardContent className="text-center">
                  <Image
                    src="/placeholder.svg?height=200&width=300"
                    width={300}
                    height={200}
                    alt="Superhéroes"
                    className="rounded-lg mx-auto mb-4"
                  />
                  <Button variant="outline" className="w-full group-hover:bg-gray-700 text-gray-300">
                    Ver Colección
                  </Button>
                </CardContent>
              </Card>

              <Card className="group hover:shadow-lg transition-all duration-300 bg-gray-800 border-gray-700 hover:border-gray-600">
                <CardHeader className="text-center">
                  <div className="mx-auto mb-4 h-16 w-16 rounded-full bg-gradient-to-r from-orange-400 to-red-400 flex items-center justify-center">
                    <BookOpen className="h-8 w-8 text-white" />
                  </div>
                  <CardTitle className="text-xl">Manga</CardTitle>
                  <CardDescription>Los mejores títulos japoneses y coreanos</CardDescription>
                </CardHeader>
                <CardContent className="text-center">
                  <Image
                    src="/placeholder.svg?height=200&width=300"
                    width={300}
                    height={200}
                    alt="Manga"
                    className="rounded-lg mx-auto mb-4"
                  />
                  <Button variant="outline" className="w-full group-hover:bg-gray-700 text-gray-300">
                    Ver Colección
                  </Button>
                </CardContent>
              </Card>

              <Card className="group hover:shadow-lg transition-all duration-300 bg-gray-800 border-gray-700 hover:border-gray-600">
                <CardHeader className="text-center">
                  <div className="mx-auto mb-4 h-16 w-16 rounded-full bg-gradient-to-r from-purple-400 to-blue-400 flex items-center justify-center">
                    <Star className="h-8 w-8 text-white" />
                  </div>
                  <CardTitle className="text-xl">Coleccionables</CardTitle>
                  <CardDescription>Figuras, pósters y artículos únicos</CardDescription>
                </CardHeader>
                <CardContent className="text-center">
                  <Image
                    src="/placeholder.svg?height=200&width=300"
                    width={300}
                    height={200}
                    alt="Coleccionables"
                    className="rounded-lg mx-auto mb-4"
                  />
                  <Button variant="outline" className="w-full group-hover:bg-gray-700 text-gray-300">
                    Ver Colección
                  </Button>
                </CardContent>
              </Card>
            </div>
          </div>
        </section>

        {/* Features Section */}
        {/* <section className="w-full py-12 md:py-24 lg:py-32 bg-gray-800">
          <div className="container px-4 md:px-6">
            <div className="grid gap-6 lg:grid-cols-[1fr_500px] lg:gap-12 xl:grid-cols-[1fr_550px]">
              <div className="flex flex-col justify-center space-y-4">
                <div className="space-y-2">
                  <Badge className="bg-gray-700 text-cyan-400 hover:bg-gray-600">¿Por qué elegirnos?</Badge>
                  <h2 className="text-3xl font-bold tracking-tighter sm:text-5xl">La mejor experiencia en comics</h2>
                  <p className="max-w-[600px] text-gray-300 md:text-xl/relaxed lg:text-base/relaxed xl:text-xl/relaxed">
                    Más de 10 años conectando a los fanáticos con sus historias favoritas
                  </p>
                </div>
                <div className="grid gap-4 sm:grid-cols-2">
                  <div className="flex items-start gap-3">
                    <div className="h-10 w-10 rounded-full bg-green-100 flex items-center justify-center flex-shrink-0">
                      <Truck className="h-5 w-5 text-green-600" />
                    </div>
                    <div>
                      <h3 className="font-semibold">Envío rápido</h3>
                      <p className="text-sm text-gray-300">Entrega en 24-48h en toda España</p>
                    </div>
                  </div>
                  <div className="flex items-start gap-3">
                    <div className="h-10 w-10 rounded-full bg-blue-100 flex items-center justify-center flex-shrink-0">
                      <Shield className="h-5 w-5 text-blue-600" />
                    </div>
                    <div>
                      <h3 className="font-semibold">Compra segura</h3>
                      <p className="text-sm text-gray-300">Pago 100% protegido y garantizado</p>
                    </div>
                  </div>
                  <div className="flex items-start gap-3">
                    <div className="h-10 w-10 rounded-full bg-purple-100 flex items-center justify-center flex-shrink-0">
                      <Users className="h-5 w-5 text-purple-600" />
                    </div>
                    <div>
                      <h3 className="font-semibold">Comunidad</h3>
                      <p className="text-sm text-gray-300">Únete a miles de coleccionistas</p>
                    </div>
                  </div>
                  <div className="flex items-start gap-3">
                    <div className="h-10 w-10 rounded-full bg-yellow-100 flex items-center justify-center flex-shrink-0">
                      <Star className="h-5 w-5 text-yellow-600" />
                    </div>
                    <div>
                      <h3 className="font-semibold">Calidad premium</h3>
                      <p className="text-sm text-gray-300">Solo productos originales y auténticos</p>
                    </div>
                  </div>
                </div>
              </div>
              <div className="flex items-center justify-center">
                <Image
                  src="/placeholder.svg?height=400&width=500"
                  width={500}
                  height={400}
                  alt="Features"
                  className="rounded-xl shadow-lg"
                />
              </div>
            </div>
          </div>
        </section> */}

        {/* Newsletter Section */}
        {/* <section className="w-full py-12 md:py-24 lg:py-32 bg-gradient-to-r from-gray-900 to-black">
          <div className="container px-4 md:px-6">
            <div className="flex flex-col items-center justify-center space-y-4 text-center">
              <div className="space-y-2">
                <h2 className="text-3xl font-bold tracking-tighter sm:text-4xl md:text-5xl text-white">
                  No te pierdas ningún lanzamiento
                </h2>
                <p className="mx-auto max-w-[600px] text-gray-300 md:text-xl/relaxed lg:text-base/relaxed xl:text-xl/relaxed">
                  Suscríbete a nuestro newsletter y recibe ofertas exclusivas, noticias y los últimos lanzamientos
                </p>
              </div>
              <div className="w-full max-w-sm space-y-2">
                <form className="flex gap-2">
                  <Input
                    type="email"
                    placeholder="tu@email.com"
                    className="max-w-lg flex-1 bg-gray-800 border-gray-600 text-gray-100 placeholder:text-gray-400"
                  />
                  <Button type="submit" className="bg-cyan-600 text-white hover:bg-cyan-700">
                    Suscribirse
                  </Button>
                </form>
                <p className="text-xs text-gray-400">
                  Al suscribirte aceptas nuestros{" "}
                  <Link href="/terminos" className="underline underline-offset-2 hover:text-white">
                    términos y condiciones
                  </Link>
                </p>
              </div>
            </div>
          </div>
        </section> */}

        {/* Stats Section */}
        {/* <section className="w-full py-12 md:py-24 lg:py-32 bg-gray-900">
          <div className="container px-4 md:px-6">
            <div className="grid gap-6 lg:grid-cols-4 md:grid-cols-2">
              <div className="flex flex-col items-center justify-center space-y-2 text-center">
                <div className="text-3xl font-bold text-cyan-400">50,000+</div>
                <div className="text-sm text-gray-300">Comics disponibles</div>
              </div>
              <div className="flex flex-col items-center justify-center space-y-2 text-center">
                <div className="text-3xl font-bold text-purple-400">25,000+</div>
                <div className="text-sm text-gray-300">Clientes satisfechos</div>
              </div>
              <div className="flex flex-col items-center justify-center space-y-2 text-center">
                <div className="text-3xl font-bold text-green-400">10+</div>
                <div className="text-sm text-gray-300">Años de experiencia</div>
              </div>
              <div className="flex flex-col items-center justify-center space-y-2 text-center">
                <div className="text-3xl font-bold text-orange-400">99%</div>
                <div className="text-sm text-gray-300">Recomendación</div>
              </div>
            </div>
          </div>
        </section> */}
      </main>

      {/* Footer */}
      <footer className="flex flex-col gap-2 sm:flex-row py-6 w-full shrink-0 items-center px-4 md:px-6 border-t border-gray-800 bg-gray-900">
        <div className="flex items-center gap-2">
          <BookOpen className="h-6 w-6 text-purple-600" />
          <span className="font-bold text-cyan-400">ComicVerse</span>
        </div>
        <p className="text-xs text-gray-400">© 2024 ComicVerse. Todos los derechos reservados.</p>
        <nav className="sm:ml-auto flex gap-4 sm:gap-6">
          <Link href="/privacidad" className="text-xs hover:underline underline-offset-4 text-gray-400">
            Privacidad
          </Link>
          <Link href="/terminos" className="text-xs hover:underline underline-offset-4 text-gray-400">
            Términos
          </Link>
          <Link href="/contacto" className="text-xs hover:underline underline-offset-4 text-gray-400">
            Contacto
          </Link>
        </nav>
      </footer>
    </div>
  ); // <--- AND THIS CLOSING PARENTHESIS
}