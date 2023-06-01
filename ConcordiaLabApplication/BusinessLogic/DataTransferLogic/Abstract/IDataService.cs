﻿using BusinessLogic.DTOs.BusinessDTO;

namespace BusinessLogic.DataTransferLogic.Abstract;

// Gli scienziati possono aggiungere un commento
// Gli scienziati possono spostare un esperimento da una scheda all'altra


public interface IDataService
{
    public List<BusinessListDto>? GetAllLists(int scientistId);

    // Per L'API ho bisogno di: Conversione IdList locale a IdTrelloList
    // Ho bisogno del Token dello scienziato
    // Ho bisogno dell'id Trello dello scienziato
    // Ho bisogno del testo del commento
    // Ho bisogno dell'idTrello dell'esperimento
    // Ho bisogno dell'id locale dell'esperimento
    // Ho bisogno dell'id dello scienziato

    // Che tipo devo restituire al Controller? Bool o basta void? O forse potrei restituire l'id dell'esperimento
    // che sono andato ad aggiornare?

    // E' meglio prendersi qui l'oggetto scientistDTO chiedendolo al DB tramite repository o e' piu'
    // facile lavorare passando gia' alla web app sottostante un oggetto di tipo ScientistDTO?
    public void AddComment(BusinessExperimentDto businessCardDto, int scientistId);
}