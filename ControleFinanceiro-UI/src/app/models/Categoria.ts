import { NumberValueAccessor } from "@angular/forms";
import { Tipo } from "./Tipo";

export class Categoria {
    categoriaId: number;
    nome: string;
    icone: string;
    tipoId: number;
    tipo: Tipo;
}