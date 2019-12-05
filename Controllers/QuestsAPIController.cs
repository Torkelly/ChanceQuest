using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChanceQuest.Data;
using ChanceQuest.Entities;
using ChanceQuest.Models.Quest;
using Microsoft.Extensions.Logging;
using ChanceQuest.Filters;

namespace ChanceQuest.Controllers
{
    [Route("api/[controller]")]
    [FeatureEnabled(IsEnabled = true)]
    [ValidateModel] 
    [EnsureQuestExists]
    [ApiController]
    public class QuestsAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<QuestsAPIController> _log;
        public QuestsAPIController(ApplicationDbContext context, ILogger<QuestsAPIController> log)
        {
            _context = context;
            _log = log;
        }

        IEnumerable<QuestViewModel> Quests = new List<QuestViewModel>() // FactionId: 1 = Peasant, 2 = Noble, 3 = Royal
        {
            new QuestViewModel()
            {
                Id = 1,
                Description = "A peasant man asks you 'My family is hungry. A Shipment of food passes by later today to the Broyle estate, can you ransack it?'"
            },
            new QuestViewModel()
            {
                Id = 2,
                Description = "A Noble man approaches. He says 'I have a proposition. I will pay you hansomely if you can do one thing. Every morning the town baker swoons over my wife. I want him fired... put this in the baker's dough.'"
            },
            new QuestViewModel()
            {
                Id = 3,
                Description = "Your royal highness summons you. 'The neighboring kingdom is occupying a town near our borders and the citizens are too welcoming! I need you to spread some... 'news' around town about the neighboring kingdom.'"
            },

            new QuestViewModel()
            {
                Id = 4,
                Description = "A little girl sells flowers for change in the town market. 'If only I could get my hands on a rarity called the 'Andromesiana' flower'. It's in the mountains. I could sell it to the nobles for a high price..."
            },

            new QuestViewModel()
            {
                Id = 5,
                Description = "A noble woman complains to you about her sister who won't shut up about her new jewels. Steal the jewels."
            },

            new QuestViewModel()
            {
                Id = 6,
                Description = "You are summoned by a princess. She asks of you 'I hear tales of a boar terrorizing the poor people of a nearby village and father does nothing! Please help the village in my name.'"
            },

            new QuestViewModel()
            {
                Id = 7, FavorableStatId = 3, FactionId = 1,
                Description = "A peasant who has been injured trying to wrestle a wild boar winces in pain. He asks you 'Oy, I need some brandy for this cut here. Mind getting me a bottle?'"
            },
            new QuestViewModel()
            {
                Id = 8,
                Description = "A noble girl has gone missing. The wealthy family is in mourning. The perpetrator has left a clue; you are asked to track her down, the reward being great if you should succeed."
            },
            new QuestViewModel()
            {
                Id = 9,
                Description = "A royal prince summons you. 'Far too long has the noble girl of the Broyle estate ignored me. Would you let me win in a fight with you so I might draw her attention?'"
            },
            new QuestViewModel()
            {
                Id = 10,
                Description = "A poor woman sobs. 'They took my family heirloom!' Upon your inquiry, she explains she was unable to pay her taxes selling produce and thus her prized family possession was taken to pay the dues. She asks you to steal it back before the family flees to the border."
            },
            new QuestViewModel()
            {
                Id = 11,
                Description = "A noble man with angry eyes approaches. He says 'My decrepit father is on his death bed and the bloody will isn't legible! How can I be sure I will enherit what is rightfully mine? Everyone will recognize my handwriting... but yours? Could you forge my father's will? '"
            },
            new QuestViewModel()
            {
                Id = 12,
                Description = "A polished boy who claims to be the youngest prince has taken a liking to you. The only problem is: he is an illegitimate child... you are asked to convince him to refrain from assuming the role of 'prince'"
            },
            new QuestViewModel()
            {
                Id = 13,
                Description = "A poor man with empty eyes stares into nothing. You catch his attention and he explains 'Everyone I have ever known has died of an illness. I would die myself but suicide will send me to hell. Could I die fighting, valliantly, by your sword?'"
            },
            new QuestViewModel()
            {
                Id = 14,
                Description = "A noble boy is teased by peers because of his terrible aim with the bow. He asks you to teach him how to hit the center of a target."
            },
            new QuestViewModel()
            {
                Id = 15,
                Description = "The royal pooch is an embarrassment. You are asked to find a dog that looks exactly like him - but whose attitude matches his royal highness's."
            },
            new QuestViewModel()
            {
                Id = 16, 
                Description = ""
            },
            new QuestViewModel()
            {
                Id = 17,
                Description = ""
            },
            new QuestViewModel()
            {
                Id = 18,
                Description = ""
            },
            new QuestViewModel()
            {
                Id = 19,
                Description = ""
            },
            new QuestViewModel()
            {
                Id = 20,
                Description = ""
            },
        };

        // GET: api/QuestsAPI
        [HttpGet]
        [Produces("application/xml")]
        public IEnumerable<Quest> GetQuests()
        {
            _log.LogInformation("No parameter GetQuests() Call Successful");
            return _context.Quests;
        }

        // GET: api/QuestsAPI/5
        [HttpGet("{id}")]
        [Produces("application/xml")]
        public async Task<IActionResult> GetQuest([FromRoute] int id)
        {

            var quest = await _context.Quests.FindAsync(id);

            return Ok(quest);
        }

        // PUT: api/QuestsAPI/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuest([FromRoute] int id, [FromBody] Quest quest)
        { 

            if (id != quest.Id)
            {
                return BadRequest();
            }

            _context.Entry(quest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/QuestsAPI
        [HttpPost]
        public async Task<IActionResult> PostQuest([FromBody] Quest quest)
        {
            _context.Quests.Add(quest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuest", new { id = quest.Id }, quest);
        }

        // DELETE: api/QuestsAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuest([FromRoute] int id)
        {
            var quest = await _context.Quests.FindAsync(id);
            _context.Quests.Remove(quest);
            await _context.SaveChangesAsync();

            return Ok(quest);
        }

        private bool QuestExists(int id)
        {
            return _context.Quests.Any(e => e.Id == id);
        }
    }
}